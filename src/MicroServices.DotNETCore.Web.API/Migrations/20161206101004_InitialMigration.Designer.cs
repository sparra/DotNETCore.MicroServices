using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MicroServices.DotNETCore.Web.API.Repository;

namespace MicroServices.DotNETCore.Web.API.Migrations
{
    [DbContext(typeof(DockerCommandsDbContext))]
    [Migration("20161206101004_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicroServices.DotNETCore.Domain.CORE.Models.DockerCommand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Command");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("DockerCommands");
                });

            modelBuilder.Entity("MicroServices.DotNETCore.Domain.CORE.Models.DockerCommandExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("DockerCommandId");

                    b.Property<string>("Example");

                    b.HasKey("Id");

                    b.HasIndex("DockerCommandId");

                    b.ToTable("DockerCommandExample");
                });

            modelBuilder.Entity("MicroServices.DotNETCore.Domain.CORE.Models.DockerCommandExample", b =>
                {
                    b.HasOne("MicroServices.DotNETCore.Domain.CORE.Models.DockerCommand")
                        .WithMany("Examples")
                        .HasForeignKey("DockerCommandId");
                });
        }
    }
}
