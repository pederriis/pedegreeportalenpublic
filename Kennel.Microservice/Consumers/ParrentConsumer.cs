using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class ParrentConsumer
    {
        //public class CreateParrentConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.CreateParrent>
        //{
        //    private readonly ParrentApplicationService _applicationService;

        //    public CreateParrentConsumer(ParrentApplicationService applicationService)
        //    {
        //        _applicationService = applicationService;
        //    }

        //    public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.CreateParrent> context)
        //    {
        //        var data = context.Message;

        //        ParrentCommandsDto.V1.CreateParrent parrent = new ParrentCommandsDto.V1.CreateParrent();

        //        parrent.ParrentId = data.ParrentId;
        //        parrent.AnimalId = data.AnimalId;
        //        parrent.LitterId = data.LitterId;
        //        parrent.IsDeleted = data.IsDeleted;

        //        await _applicationService.Handle(parrent);
        //    }
        //}

        //public class DeleteParrentConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.DeleteParrent>
        //{
        //    private readonly ParrentApplicationService _applicationService;

        //    public DeleteParrentConsumer(ParrentApplicationService applicationService)
        //    {
        //        _applicationService = applicationService;
        //    }

        //    public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.DeleteParrent> context)
        //    {
        //        var data = context.Message;

        //        ParrentCommandsDto.V1.DeleteParrent parrent = new ParrentCommandsDto.V1.DeleteParrent();

        //        parrent.ParrentId = data.ParrentId;
        //        parrent.IsDeleted = data.IsDeleted;

        //        await _applicationService.Handle(parrent);
        //    }
        //}

        //public class AddParrentToLitterConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.AddParrentToLitter>
        //{
        //    private readonly ParrentApplicationService _applicationService;

        //    public AddParrentToLitterConsumer(ParrentApplicationService applicationService)
        //    {
        //        _applicationService = applicationService;
        //    }

        //    public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.AddParrentToLitter> context)
        //    {
        //        var data = context.Message;

        //        ParrentCommandsDto.V1.AddParrentToLitter parrent = new ParrentCommandsDto.V1.AddParrentToLitter();

        //        parrent.ParrentId = data.ParrentId;
        //        parrent.LitterId = data.LitterId;

        //        await _applicationService.Handle(parrent);
        //    }
        //}
    }
}
