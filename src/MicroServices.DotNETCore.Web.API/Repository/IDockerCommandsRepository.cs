using MicroServices.DotNETCore.Domain.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.DotNETCore.Web.API.Repository
{
    public interface IDockerCommandsRepository
    {
        Task<List<DockerCommand>> GetDockerCommandsAsync();

        Task InsertDockerCommandAsync(DockerCommand command);
    }
}
