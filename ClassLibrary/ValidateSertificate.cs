﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class ValidateSertificate
    {

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate,
X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


    }
}
