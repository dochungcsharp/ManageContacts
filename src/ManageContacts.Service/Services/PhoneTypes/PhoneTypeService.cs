using AutoMapper;
using ManageContacts.Entity.Contexts;
using ManageContacts.Entity.Entities;
using ManageContacts.Infrastructure.Abstractions;
using ManageContacts.Infrastructure.UnitOfWork;
using ManageContacts.Model.Abstractions.Responses;
using ManageContacts.Model.Models.PhoneTypes;
using ManageContacts.Shared.Extensions;

namespace ManageContacts.Service.Services.PhoneTypes;

public class PhoneTypeService : IPhoneTypeService
{
    private readonly IRepository<PhoneType> _addressTypeRepository;
    private readonly IMapper _mapper;
    
    public PhoneTypeService(IUnitOfWork<ContactsContext> uow, IMapper mapper)
    {
        _mapper = _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _addressTypeRepository = uow.GetRepository<PhoneType>();
    }
    
    public async Task<OkResponseModel<PhoneTypeModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var phoneTypes = await _addressTypeRepository.FindAllAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        
        if(phoneTypes.NotNullOrEmpty())
            return new OkResponseModel<PhoneTypeModel>(_mapper.Map<PhoneTypeModel>(phoneTypes));

        return new OkResponseModel<PhoneTypeModel>();
        
    }
}