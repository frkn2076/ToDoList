using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI {
    public interface IEncryptor {
        string MD5Hash(string text);
    }
}
