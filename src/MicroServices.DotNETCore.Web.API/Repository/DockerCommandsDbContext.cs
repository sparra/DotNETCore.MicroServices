using MicroServices.DotNETCore.Domain.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.DotNETCore.Web.API.Repository
{
    public class DockerCommandsDbContext : DbContext
    {
        public DbSet<DockerCommand> DockerCommands { get; set; }

        public DockerCommandsDbContext(DbContextOptions<DockerCommandsDbContext> options) : base(options) { }
    }
}
