namespace tetofo.Event.Impl;

public class Bus : IBus
{
    private readonly IRegistry _registry;
    public Bus (IRegistry registry) {
        _registry = registry;
    }

    public async Task<IEnumerable<S>> EventAsync<R, S>(R r)
        where R : IEvent
        where S : IResult
    {
        IEnumerable<ICallback<R,S>> callbacks = _registry.GetCallbacks<R,S>();
        IList<S> results = new List<S>();
        if (callbacks == null || !callbacks.Any()) {
            return results;
        }
        foreach(ICallback<R,S> callback in callbacks) {
            results.Add(await callback.CallbackAsync(r));
        }
        return results;
    }
}