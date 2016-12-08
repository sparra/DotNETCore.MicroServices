using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.DotNETCore.Domain.CORE.Models
{
    public class DockerCommand
    {
        public int Id { get; set; }
        public string Command { get; set; }
        public string Description { get; set; }
        public List<DockerCommandExample> Examples { get; set; }
    }
}
