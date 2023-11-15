namespace tetofo.Event;

public interface ICallback<R, S> where R : IEvent where S : IResult {
    Task<S> CallbackAsync(R r);
}