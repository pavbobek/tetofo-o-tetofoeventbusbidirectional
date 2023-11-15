namespace tetofo.Event;

public interface IRegistry {
    IEnumerable<ICallback<R,S>> GetCallbacks<R,S>() where R : IEvent where S : IResult;
}