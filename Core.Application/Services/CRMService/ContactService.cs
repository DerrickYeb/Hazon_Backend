﻿using Core.Application.Abstractions.Services.CRMService;
using Core.Application.Repositories;
using Core.Domain.Models;

namespace Core.Application.Services.CRMService
{
    public class ContactService:IContactService
    {
        private readonly IRepository<ClientDetailsModel> _repository;

        public ContactService(IRepository<ClientDetailsModel> repository)
        {
            _repository = repository;
        }

        public async Task<ClientDetailsModel> CreateContact(ClientDetailsModel contact)
        {
            var exist = await _repository.ExistAsync<ClientDetailsModel>(a => a.Email == contact.Email);
            if (exist is not null) throw new Exception("Contact already exist");
            var result = await _repository.CreateAsync(contact);
            await _repository.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteContact(Guid contactId)
        {
            var result =await _repository.RemoveByIdAsync<ClientDetailsModel>(contactId);
            if (result is false) throw new Exception("Failed to delete contact");
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<Guid> UpdateContactDetails(ClientDetailsModel contact)
        {
            var exist = await _repository.ExistAsync<ClientDetailsModel>(a =>
                a.Id == contact.Id && a.TenantKey == contact.TenantKey);
            if (exist is null) throw new Exception("Failed to update contact info");
            exist.FirstName = contact.FirstName;
            exist.LastName = contact.LastName;
            exist.Email= contact.Email;
            exist.Contact = contact.Contact;
            exist.Address = contact.Address;
            exist.MiddleName = contact.MiddleName;
            exist.ClientTypeId = contact.ClientTypeId;
            exist.DOB = contact.DOB;

            await _repository.UpdateAsync(exist);
            return exist.Id;
        }

        public async Task<ClientDetailsModel> GetContact(Guid contactId)
        {
            return await _repository.GetByIdAsync<ClientDetailsModel>(contactId);
        }

        public Task<ClientDetailsModel> MoveContactToBusiness(Guid contactId, ClientDetailsModel contact)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientDetailsModel>> GetAllContacts()
        {
            return await _repository.GetAllAsync<ClientDetailsModel>();
        }
    }
}
