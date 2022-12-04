using System;

namespace WebAPI
{
    public class AzureTableSettings
    {
        public AzureTableSettings(/*string storageAccount,
                                       string storageKey,*/
                                       string connectionString
                                    //    string tableName
                                    )
        {
            // if (string.IsNullOrEmpty(storageAccount))
            //     throw new ArgumentNullException("StorageAccount");

            // if (string.IsNullOrEmpty(storageKey))
            //     throw new ArgumentNullException("StorageKey");

            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("ConnectionString");

            // if (string.IsNullOrEmpty(tableName))
            //     throw new ArgumentNullException("TableName");

            // this.StorageAccount = storageAccount;
            // this.StorageKey = storageKey;
            this.ConnectionString=connectionString;
            // this.TableName = tableName;
        }

        // public string StorageAccount { get; }
        // public string StorageKey { get; }
        public string ConnectionString {get;}
        // public string TableName { get; }
    }
}