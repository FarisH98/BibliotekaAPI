// <auto-generated />
using BibliotekaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotekaAPI.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20230222164422_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotekaAPI.Data.Biblitoeka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BrojRadnika")
                        .HasColumnType("float");

                    b.Property<double>("MjesecnaClanarina")
                        .HasColumnType("float");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RadniDani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bibliotekas");
                });

            modelBuilder.Entity("BibliotekaAPI.Data.Knjige", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("MjesecnoIzdavana")
                        .HasColumnType("float");

                    b.Property<string>("NazivKnjige")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisKnjige")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Knjiges");
                });

            modelBuilder.Entity("BibliotekaAPI.Data.Radnici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BrojRadnihSati")
                        .HasColumnType("float");

                    b.Property<string>("NazivRadnika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Plata")
                        .HasColumnType("float");

                    b.Property<double>("Rejting")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Radnicis");
                });
#pragma warning restore 612, 618
        }
    }
}
