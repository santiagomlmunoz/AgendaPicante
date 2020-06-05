using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Extensions
{
    public static class EncriptarString
    {
        public static byte[] Encriptar(this string data) =>
    new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(data));
    }
}
