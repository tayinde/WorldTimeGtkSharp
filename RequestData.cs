namespace APIRequest
{
    class DataToSend<T>
    {
        public T data;
        public DataToSend(T data)
        {
            this.data = data;
        }
    }
}