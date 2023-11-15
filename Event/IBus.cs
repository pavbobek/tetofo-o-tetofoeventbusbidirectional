namespace tetofo.Event;

public interface IBus {
    Task<IEnumerable<S>> EventAsync<R, S>(R r) where R : IEvent where S : IResult;
}