﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polls.Api.Data;

#nullable disable

namespace Polls.Api.Migrations.PollingDb
{
    [DbContext(typeof(PollingDbContext))]
    [Migration("20241017142049_Initial_PollingDbContext")]
    partial class Initial_PollingDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Option", b =>
                {
                    b.HasOne("Polls.Api.Data.DomainModels.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Question", b =>
                {
                    b.HasOne("Polls.Api.Data.DomainModels.Poll", "Poll")
                        .WithMany("Questions")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Poll", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Polls.Api.Data.DomainModels.Question", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
