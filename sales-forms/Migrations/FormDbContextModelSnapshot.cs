﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sales_forms.Data;

#nullable disable

namespace sales_forms.Migrations
{
    [DbContext(typeof(FormDbContext))]
    partial class FormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("sales_forms.Models.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("OptionId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            OptionId = 1L,
                            ParticipantId = 1L,
                            QuestionId = 1L
                        });
                });

            modelBuilder.Entity("sales_forms.Models.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "885aa077-cdc8-43b3-9c67-ddd2bec3efa8",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Test User",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("sales_forms.Models.Folder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Test Folder"
                        });
                });

            modelBuilder.Entity("sales_forms.Models.FolderPermission", b =>
                {
                    b.Property<long>("FolderId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessType")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FolderId", "AppUserId");

                    b.HasIndex("UserId");

                    b.ToTable("FolderPermissions");

                    b.HasData(
                        new
                        {
                            FolderId = 1L,
                            AppUserId = 1L,
                            AccessType = 1,
                            Id = 1L
                        });
                });

            modelBuilder.Entity("sales_forms.Models.Form", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("FolderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Forms");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FolderId = 1L,
                            Name = "Test Form"
                        });
                });

            modelBuilder.Entity("sales_forms.Models.Option", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            QuestionId = 1L,
                            Value = "Test Option",
                            Weight = 10
                        });
                });

            modelBuilder.Entity("sales_forms.Models.Participant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Test Participant"
                        });
                });

            modelBuilder.Entity("sales_forms.Models.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("FormId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Expression = "Test Question",
                            FormId = 1L
                        });
                });

            modelBuilder.Entity("sales_forms.Models.Answer", b =>
                {
                    b.HasOne("sales_forms.Models.Participant", "Participant")
                        .WithMany("Answers")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sales_forms.Models.Option", "Option")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sales_forms.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Participant");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("sales_forms.Models.FolderPermission", b =>
                {
                    b.HasOne("sales_forms.Models.Folder", "Folder")
                        .WithMany("Permissions")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sales_forms.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AppUser");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("sales_forms.Models.Form", b =>
                {
                    b.HasOne("sales_forms.Models.Folder", "Folder")
                        .WithMany("Forms")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("sales_forms.Models.Option", b =>
                {
                    b.HasOne("sales_forms.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("sales_forms.Models.Question", b =>
                {
                    b.HasOne("sales_forms.Models.Form", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("sales_forms.Models.Folder", b =>
                {
                    b.Navigation("Forms");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("sales_forms.Models.Form", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("sales_forms.Models.Participant", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("sales_forms.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
