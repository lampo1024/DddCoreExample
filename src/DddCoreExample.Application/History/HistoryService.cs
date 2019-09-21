using System.Collections.Generic;
using AutoMapper;
using DddCoreExample.Domain;
using DddCoreExample.Domain.Repository;

namespace DddCoreExample.Application.History
{
    public class HistoryService : IHistoryService
    {
        readonly IDomainEventRepository _domainEventRepository;
        private readonly IMapper _mapper;

        public HistoryService(IDomainEventRepository domainEventRepository, IMapper mapper)
        {
            _domainEventRepository = domainEventRepository;
            _mapper = mapper;
        }

        public HistoryDto GetHistory()
        {
            var events = _domainEventRepository.FindAll();

            var history = new HistoryDto { Events = _mapper.Map<IEnumerable<DomainEventRecord>, List<EventDto>>(events) };

            return history;
        }
    }
}
