using Dapper;
using testeDapper.API.Models;

namespace testeDapper.API;

public class NotificationRepository
{
    private DbSession _session;

    public NotificationRepository(DbSession session)
    {
        _session = session;
    }

    public IEnumerable<NotificationModel> Get()
    {
        return _session.Connection.Query<NotificationModel>("SELECT * FROM [Notifications]", null, _session.Transaction);
    }

    public void Save(NotificationModel model)
    {
        _session.Connection.Execute($"INSERT INTO [Notifications] VALUES ('{model.Title}', '{model.Message}')", null, _session.Transaction);
    }
}