namespace HotelReservation.Services
{
    public interface IHotelReservation<T>
    {
        public IEnumerable<T> getAll();
       // public IEnumerable<T> getProperty();
        public T getOne(int? id);
        public void addOne(T t);
        public void updateOne(T t);
        public void deleteOne(int? id);

    }
}
