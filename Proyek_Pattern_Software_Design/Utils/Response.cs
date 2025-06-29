﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Utils
{
	public class Response<T>
    {
        public int statusCode;
        public string message;
        public T data;
        public Response(int statusCode, string message, T data)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.data = data;
        }
    }
}