using System.Data;

namespace Simpl.Core.Databases
{
    public interface IDatabase
    {
        IDbConnection OpenConnection();
    }
}
