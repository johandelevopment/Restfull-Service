

using System.Configuration;

namespace Data.StoredProcedure
{
    public class Conection
    {
        public string GetConnectionString()
        {
            string conexionString = "";
            var prod = EncryptionManager.Decrypt("kPpN+ncRSXeJHLpuqqOSa97k7hobl3V8PblQZmsXuxdhKHnvI1dum+9fRxTSLvPN5IuAWy1+5fQL9TPsLKk++nV/ndwgIJ2dQjQ30I/jIrpvOBtprKpkGunNqIeMG0lagE7GzSKN4bs2I1rfI1cwWj3cQzQvsMIoFjdaojL0zrLaBlQW4O7N+jlQ9FvZeQXepWGqARzMAy8f4j8IzkP8XJiuvw5dvDZdhww0K4QsvXweKcxTt6feooANQsSVc6ktMnKTByVtGrd4XwjC9Q32LF78o3CWe/MLlqQaoimzjDE2SYL7FvMBdVTdZsBZXePTxpKJ9IgVAcr6TeZGoAYSMzBQoLHRXayeV0cuVOy8cunXh5ST2hMQiSlVgxpfWuU0XTMZzK40CEVgIqnXtm8Mpx2I9JwnC/hATVlTbvSQOG7oEvq0YCJrUbbYefxz35BGlEhmSM1u72zhh2HQssQTB4cNanuIt62agyfDaZ+4H2ktUrcjNRcA/c0jgPlFlesDAihv00lsUo4K+K/8fJ39jQ==");
            var encrypt = EncryptionManager.Encrypt(prod);
            conexionString = prod;

            return conexionString;
        }
    }
}
