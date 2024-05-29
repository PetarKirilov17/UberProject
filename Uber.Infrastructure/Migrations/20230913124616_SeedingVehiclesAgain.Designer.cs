﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using Uber.Infrastructure.Data;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230913124616_SeedingVehiclesAgain")]
    partial class SeedingVehiclesAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DriverVehicle", b =>
                {
                    b.Property<int>("DriversDriverId")
                        .HasColumnType("integer")
                        .HasColumnName("drivers_driver_id");

                    b.Property<int>("VehiclesVehicleId")
                        .HasColumnType("integer")
                        .HasColumnName("vehicles_vehicle_id");

                    b.HasKey("DriversDriverId", "VehiclesVehicleId")
                        .HasName("pk_driver_vehicle");

                    b.HasIndex("VehiclesVehicleId")
                        .HasDatabaseName("ix_driver_vehicle_vehicles_vehicle_id");

                    b.ToTable("driver_vehicle", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("address_id")
                        .HasComment("Primary Key of the Address Entity.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressId"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description")
                        .HasComment("Field that is used to make addtional description for the Address Entity which is optional.");

                    b.Property<NpgsqlPoint?>("Location")
                        .HasColumnType("point")
                        .HasColumnName("location")
                        .HasComment("Field that describes the exact locaion of the address by x and y coordinates.");

                    b.HasKey("AddressId")
                        .HasName("pk_addresses");

                    b.ToTable("addresses", (string)null);

                    b.HasComment("This is a class that describes the Address Entity in the application.");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("client_id")
                        .HasComment("Primary Key for the Client Entity.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClientId"));

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("person_id")
                        .HasComment("Foreign Key that describes the 'is a' relationship between the Client and the Person.");

                    b.Property<bool>("isRegularCustomer")
                        .HasColumnType("boolean")
                        .HasColumnName("is_regular_customer")
                        .HasComment("Field that describes whether the client is regular.");

                    b.HasKey("ClientId")
                        .HasName("pk_clients");

                    b.HasIndex("PersonId")
                        .HasDatabaseName("ix_clients_person_id");

                    b.ToTable("clients", (string)null);

                    b.HasComment("This is a class that describes the Client Entity in the apllication. The Client is one of the roles in the application.");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("driver_id")
                        .HasComment("Primary Key for the Driver Entity.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DriverId"));

                    b.Property<NpgsqlPoint?>("CurrentPosition")
                        .HasColumnType("point")
                        .HasColumnName("current_position")
                        .HasComment("Field that describes the current locaion of the driver by x and y coordinates.");

                    b.Property<string>("DrivingLicence")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("driving_licence")
                        .HasComment("Field that contains information about the driving licence of the driver.");

                    b.Property<int>("Experience")
                        .HasColumnType("integer")
                        .HasColumnName("experience")
                        .HasComment("Filed for the years of experience of the driver.");

                    b.Property<bool>("IsDriverApproved")
                        .HasColumnType("boolean")
                        .HasColumnName("is_driver_approved")
                        .HasComment("Field that tells whether the driver is approved by the admin");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("person_id")
                        .HasComment("Foreign Key that describes the 'is a' relationship between the Driver and the Person.");

                    b.HasKey("DriverId")
                        .HasName("pk_drivers");

                    b.HasIndex("PersonId")
                        .HasDatabaseName("ix_drivers_person_id");

                    b.ToTable("drivers", (string)null);

                    b.HasComment("This is a class that describes the Driver Entity in the apllication. The Driver is one of the roles in the application.");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<int>("OdrerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("odrer_id")
                        .HasComment("Primary Key of the Order Entity.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OdrerId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id")
                        .HasComment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Client. Contains information about the client that made the order.");

                    b.Property<short>("CountOfPassengers")
                        .HasColumnType("smallint")
                        .HasColumnName("count_of_passengers")
                        .HasComment("Field that saves the count of the passengers of the order.");

                    b.Property<int>("CurrentAddressId")
                        .HasColumnType("integer")
                        .HasColumnName("current_address_id")
                        .HasComment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the current address of the order.");

                    b.Property<int>("DestinationId")
                        .HasColumnType("integer")
                        .HasColumnName("destination_id")
                        .HasComment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the destination address of the order.");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id")
                        .HasComment("Foreign Key that describes a 'one-to-many' relationship between the Order and Driver. Contains information about the driver that will run the order.");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer")
                        .HasColumnName("vehicle_id")
                        .HasComment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Vehicle. Contains information about the vehicle with which the order will be run.");

                    b.HasKey("OdrerId")
                        .HasName("pk_orders");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_orders_client_id");

                    b.HasIndex("CurrentAddressId")
                        .HasDatabaseName("ix_orders_current_address_id");

                    b.HasIndex("DestinationId")
                        .HasDatabaseName("ix_orders_destination_id");

                    b.HasIndex("DriverId")
                        .HasDatabaseName("ix_orders_driver_id");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_orders_vehicle_id");

                    b.ToTable("orders", (string)null);

                    b.HasComment("This is a class that describes the Order Entity in the application.");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasComment("Primary Key for the Person entity.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age")
                        .HasComment("Field for the age of the person.");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name")
                        .HasComment("Field for the first name of the person.");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("gender")
                        .HasComment("Field for the gender of the person.");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name")
                        .HasComment("Field for the last name of the person.");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id")
                        .HasComment("Foreign Key that is used to connect the Person Entity with the IdentityUser in the application.");

                    b.HasKey("Id")
                        .HasName("pk_people");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_people_user_id");

                    b.ToTable("people", (string)null);

                    b.HasComment("This is a base entity for a person in the application.");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("vehicle_id")
                        .HasComment("Primary Key for the Vehicle Entity.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("brand")
                        .HasComment("Field that describes the brand of the vehicle.");

                    b.Property<short>("MaxSeats")
                        .HasColumnType("smallint")
                        .HasColumnName("max_seats")
                        .HasComment("Field that saves the max count of the vehicle seats.");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("model")
                        .HasComment("Field that describes the model of the vehicle.");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("vehicle_type_id")
                        .HasComment("Foreign Key that describes a 'one-to-many' relationship between the Vehicle and the VehicleType. Contains information about the type of the vehicle.");

                    b.Property<short>("YearOfProduction")
                        .HasColumnType("smallint")
                        .HasColumnName("year_of_production")
                        .HasComment("Field that saves the year of the production the vehicle seats.");

                    b.HasKey("VehicleId")
                        .HasName("pk_vehicles");

                    b.HasIndex("VehicleTypeId")
                        .HasDatabaseName("ix_vehicles_vehicle_type_id");

                    b.ToTable("Vehicles", (string)null);

                    b.HasComment("This is a class that describes the Vehicle Entity in the application.");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Brand = "BMW",
                            MaxSeats = (short)5,
                            Model = "X4",
                            VehicleTypeId = 1,
                            YearOfProduction = (short)2020
                        },
                        new
                        {
                            VehicleId = 2,
                            Brand = "Audi",
                            MaxSeats = (short)5,
                            Model = "A6",
                            VehicleTypeId = 1,
                            YearOfProduction = (short)2019
                        });
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.VehicleType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("type_id")
                        .HasComment("Identfier of the vehicle type.");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TypeId"));

                    b.Property<int?>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("label")
                        .HasComment("Label that contains the type.");

                    b.HasKey("TypeId")
                        .HasName("pk_vehicle_type");

                    b.HasIndex("DriverId")
                        .HasDatabaseName("ix_vehicle_type_driver_id");

                    b.ToTable("VehicleType", (string)null);

                    b.HasComment("This is a class that describes the VehicleType Entity in the application.");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Label = "Car"
                        },
                        new
                        {
                            TypeId = 2,
                            Label = "Van"
                        },
                        new
                        {
                            TypeId = 3,
                            Label = "SUV"
                        },
                        new
                        {
                            TypeId = 4,
                            Label = "Cabriolet"
                        });
                });

            modelBuilder.Entity("DriverVehicle", b =>
                {
                    b.HasOne("Uber.Infrastructure.Data.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriversDriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_driver_vehicle_drivers_drivers_driver_id");

                    b.HasOne("Uber.Infrastructure.Data.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_driver_vehicle_vehicles_vehicles_vehicle_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Client", b =>
                {
                    b.HasOne("Uber.Infrastructure.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_clients_people_person_id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Driver", b =>
                {
                    b.HasOne("Uber.Infrastructure.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_drivers_people_person_id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("Uber.Infrastructure.Data.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_clients_client_id");

                    b.HasOne("Uber.Infrastructure.Data.Models.Address", "CurrentAddress")
                        .WithMany()
                        .HasForeignKey("CurrentAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_addresses_current_address_id");

                    b.HasOne("Uber.Infrastructure.Data.Models.Address", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_addresses_destination_id");

                    b.HasOne("Uber.Infrastructure.Data.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_drivers_driver_id");

                    b.HasOne("Uber.Infrastructure.Data.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_vehicles_vehicle_id");

                    b.Navigation("Client");

                    b.Navigation("CurrentAddress");

                    b.Navigation("Destination");

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Person", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_people_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.HasOne("Uber.Infrastructure.Data.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicles_vehicle_type_vehicle_type_id");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.VehicleType", b =>
                {
                    b.HasOne("Uber.Infrastructure.Data.Models.Driver", null)
                        .WithMany("VehicleCategories")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("fk_vehicle_type_drivers_driver_id");
                });

            modelBuilder.Entity("Uber.Infrastructure.Data.Models.Driver", b =>
                {
                    b.Navigation("VehicleCategories");
                });
#pragma warning restore 612, 618
        }
    }
}