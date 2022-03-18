namespace NMediatController
{
    using MediatR;

    public interface IEnvelopeRequest<T> : IRequest<Envelope<T>>
    {
    }
}
