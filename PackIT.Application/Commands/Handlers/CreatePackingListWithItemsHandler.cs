﻿using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Commands;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListReadService _readService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory,
            IPackingListReadService readService, IWeatherService weatherService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            // As 'command' is a Record, let's use record decomposition
            var (id, name, days, gender, localizationWriteModel) = command;

            // Ensures idempotency by not creating the same list more than once
            if (await _readService.ExistsByNameAsync(name))
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packingList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);
            await _repository.AddAsync(packingList);
        }
    }
}