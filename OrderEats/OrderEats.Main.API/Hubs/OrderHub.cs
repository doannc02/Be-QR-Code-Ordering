using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

public class OrderHub : Hub
{
    // Lưu connectionId và thông tin người dùng (name, id)
    private static Dictionary<string, (string Name, string Id)> userConnections = new Dictionary<string, (string, string)>();

    // Lưu thông tin phòng của người dùng
    private static Dictionary<string, string> userRooms = new Dictionary<string, string>();

    // Khi người dùng kết nối
    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;

        // Nhận thông tin người dùng từ client
        string userId = Context.GetHttpContext().Request.Query["userId"];  // Lấy userId từ query string hoặc có thể là từ Body
        string userName = Context.GetHttpContext().Request.Query["userName"]; // Lấy userName từ query string hoặc có thể là từ Body

        // Lưu thông tin người dùng và connectionId vào dictionary
        userConnections[connectionId] = (userName, userId);

        // Gửi lại danh sách người dùng khi có sự thay đổi kết nối
        await SendUsersListToClients();

        Console.WriteLine($"User {userName} ({userId}) connected with ConnectionId: {connectionId}");

        await base.OnConnectedAsync();
    }

    // Khi người dùng ngắt kết nối
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var connectionId = Context.ConnectionId;

        // Xóa thông tin người dùng khi ngắt kết nối
        if (userConnections.ContainsKey(connectionId))
        {
            var user = userConnections[connectionId];
            Console.WriteLine($"User {user.Name} ({user.Id}) disconnected.");
            userConnections.Remove(connectionId);
        }

        // Gửi lại danh sách người dùng khi có sự thay đổi kết nối
        await SendUsersListToClients();

        await base.OnDisconnectedAsync(exception);
    }

    // Gửi lại danh sách người dùng cho tất cả các client
    private async Task SendUsersListToClients()
    {
        var usersList = userConnections.Values.Select(u => new { u.Name, u.Id }).ToList();
        await Clients.All.SendAsync("UsersInRoom", usersList);  // Gửi danh sách người dùng cho tất cả client
    }

    // Gửi tin nhắn đến người dùng cụ thể theo connectionId hoặc userId
    public async Task SendMessageToUser(string userId, string message)
    {
        // Tìm connectionId từ userId
        var connectionId = userConnections.FirstOrDefault(x => x.Value.Id == userId).Key;

        if (!string.IsNullOrEmpty(connectionId))
        {
            // Gửi tin nhắn cho người dùng dựa trên connectionId
            Console.WriteLine($"Sending message: {message} to user {userId}");
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }
        else
        {
            Console.WriteLine($"User {userId} not found.");
        }
    }

    // Thêm người dùng vào một nhóm (room)
    public async Task JoinRoom(string userId)
    {
        var connectionId = Context.ConnectionId;

        // Lưu phòng của người dùng
        userRooms[connectionId] = userId;

        // Thêm người dùng vào nhóm theo userId
        await Groups.AddToGroupAsync(connectionId, userId);

        Console.WriteLine($"User {userId} joined the room with ConnectionId {connectionId}");
    }
}
