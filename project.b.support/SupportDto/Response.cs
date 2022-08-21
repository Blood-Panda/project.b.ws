using project.b.support.SupportUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.support.SupportDto
{
    public class Response<T>
    {
        public Response()
        {
            _isSuccess = false;
            ErrorDetails = new ErrorDetails();
            this.Nuevo = true;
        }

        public bool Nuevo { get; set; }
        public string Mensaje { get; set; }
        public T Dato { get; set; }
        public string MensajeDev { get; set; }
        public ErrorDetails ErrorDetails { get; set; }

        private bool _isSuccess;
        public bool IsSuccess
        {
            get => _isSuccess;
            set
            {
                _isSuccess = value;
                if (!value)
                    ErrorDetails = new ErrorDetails();
                else
                    ErrorDetails = null;
            }
        }
        public Response<T> Ok(T dato)
        {
            this.Mensaje = Message.correcto;
            this.Dato = dato;
            return this;
        }
    }

    public class Response
    {
        public bool Nuevo { get; set; }
        public string Mensaje { get; set; }
        public string MensajeDev { get; set; }
        public bool Success { get; set; }
        public Response Ok()
        {
            this.Mensaje = Message.correcto;
            return this;
        }
    }
}