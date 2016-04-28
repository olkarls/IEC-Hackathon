using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GarbageCollectr.Web.Data;

namespace GarbageCollectr.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GarbageCollectr.Web.Data.Models.Container", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GarbageCollectr.Web.Data.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContainerId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GarbageCollectr.Web.Data.Models.Thing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("MaterialId");

                    b.Property<string>("TagName");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GarbageCollectr.Web.Data.Models.Material", b =>
                {
                    b.HasOne("GarbageCollectr.Web.Data.Models.Container")
                        .WithMany()
                        .HasForeignKey("ContainerId");
                });

            modelBuilder.Entity("GarbageCollectr.Web.Data.Models.Thing", b =>
                {
                    b.HasOne("GarbageCollectr.Web.Data.Models.Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });
        }
    }
}
