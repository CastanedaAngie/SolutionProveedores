namespace sistem_supplier.API.Utilidad
{
    public class Response <T>
    {
        public bool Status {  get; set; }

        public T Value { get; set; }

        public String Msg { get; set; }

    }

}
