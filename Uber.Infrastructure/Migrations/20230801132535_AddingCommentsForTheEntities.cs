using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingCommentsForTheEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "vehicles",
                comment: "This is a class that describes the Vehicle Entity in the application.");

            migrationBuilder.AlterTable(
                name: "vehicle_type",
                comment: "This is a class that describes the VehicleType Entity in the application.");

            migrationBuilder.AlterTable(
                name: "people",
                comment: "This is a base entity for a person in the application.");

            migrationBuilder.AlterTable(
                name: "orders",
                comment: "This is a class that describes the Order Entity in the application.");

            migrationBuilder.AlterTable(
                name: "drivers",
                comment: "This is a class that describes the Driver Entity in the apllication. The Driver is one of the roles in the application.");

            migrationBuilder.AlterTable(
                name: "clients",
                comment: "This is a class that describes the Client Entity in the apllication. The Client is one of the roles in the application.");

            migrationBuilder.AlterTable(
                name: "addresses",
                comment: "This is a class that describes the Address Entity in the application.");

            migrationBuilder.AlterColumn<short>(
                name: "year_of_production",
                table: "vehicles",
                type: "smallint",
                nullable: false,
                comment: "Field that saves the year of the production the vehicle seats.",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "vehicle_type_id",
                table: "vehicles",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Vehicle and the VehicleType. Contains information about the type of the vehicle.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "model",
                table: "vehicles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Field that describes the model of the vehicle.",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<short>(
                name: "max_seats",
                table: "vehicles",
                type: "smallint",
                nullable: false,
                comment: "Field that saves the max count of the vehicle seats.",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "brand",
                table: "vehicles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Field that describes the brand of the vehicle.",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "vehicle_id",
                table: "vehicles",
                type: "integer",
                nullable: false,
                comment: "Primary Key for the Vehicle Entity.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "label",
                table: "vehicle_type",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Label that contains the type.",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "type_id",
                table: "vehicle_type",
                type: "integer",
                nullable: false,
                comment: "Identfier of the vehicle type.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "people",
                type: "text",
                nullable: false,
                comment: "Foreign Key that is used to connect the Person Entity with the IdentityUser in the application.",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "people",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Field for the last name of the person.",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "people",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Field for the gender of the person.",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "people",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Field for the first name of the person.",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "people",
                type: "integer",
                nullable: false,
                comment: "Field for the age of the person.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "people",
                type: "integer",
                nullable: false,
                comment: "Primary Key for the Person entity.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "vehicle_id",
                table: "orders",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Vehicle. Contains information about the vehicle with which the order will be run.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "driver_id",
                table: "orders",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Order and Driver. Contains information about the driver that will run the order.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "destination_id",
                table: "orders",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the destination address of the order.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "current_address_id",
                table: "orders",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the current address of the order.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "count_of_passengers",
                table: "orders",
                type: "smallint",
                nullable: false,
                comment: "Field that saves the count of the passengers of the order.",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "client_id",
                table: "orders",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Client. Contains information about the client that made the order.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "odrer_id",
                table: "orders",
                type: "integer",
                nullable: false,
                comment: "Primary Key of the Order Entity.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "person_id",
                table: "drivers",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes the 'is a' relationship between the Driver and the Person.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "experience",
                table: "drivers",
                type: "integer",
                nullable: false,
                comment: "Filed for the years of experience of the driver.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "driving_licence",
                table: "drivers",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                comment: "Field that contains information about the driving licence of the driver.",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<NpgsqlPoint>(
                name: "current_position",
                table: "drivers",
                type: "point",
                nullable: true,
                comment: "Field that describes the current locaion of the driver by x and y coordinates.",
                oldClrType: typeof(NpgsqlPoint),
                oldType: "point",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "driver_id",
                table: "drivers",
                type: "integer",
                nullable: false,
                comment: "Primary Key for the Driver Entity.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "person_id",
                table: "clients",
                type: "integer",
                nullable: false,
                comment: "Foreign Key that describes the 'is a' relationship between the Client and the Person.",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_regular_customer",
                table: "clients",
                type: "boolean",
                nullable: false,
                comment: "Field that describes whether the client is regular.",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "client_id",
                table: "clients",
                type: "integer",
                nullable: false,
                comment: "Primary Key for the Client Entity.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<NpgsqlPoint>(
                name: "location",
                table: "addresses",
                type: "point",
                nullable: true,
                comment: "Field that describes the exact locaion of the address by x and y coordinates.",
                oldClrType: typeof(NpgsqlPoint),
                oldType: "point",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "addresses",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                comment: "Field that is used to make addtional description for the Address Entity which is optional.",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "addresses",
                type: "integer",
                nullable: false,
                comment: "Primary Key of the Address Entity.",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "vehicles",
                oldComment: "This is a class that describes the Vehicle Entity in the application.");

            migrationBuilder.AlterTable(
                name: "vehicle_type",
                oldComment: "This is a class that describes the VehicleType Entity in the application.");

            migrationBuilder.AlterTable(
                name: "people",
                oldComment: "This is a base entity for a person in the application.");

            migrationBuilder.AlterTable(
                name: "orders",
                oldComment: "This is a class that describes the Order Entity in the application.");

            migrationBuilder.AlterTable(
                name: "drivers",
                oldComment: "This is a class that describes the Driver Entity in the apllication. The Driver is one of the roles in the application.");

            migrationBuilder.AlterTable(
                name: "clients",
                oldComment: "This is a class that describes the Client Entity in the apllication. The Client is one of the roles in the application.");

            migrationBuilder.AlterTable(
                name: "addresses",
                oldComment: "This is a class that describes the Address Entity in the application.");

            migrationBuilder.AlterColumn<short>(
                name: "year_of_production",
                table: "vehicles",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComment: "Field that saves the year of the production the vehicle seats.");

            migrationBuilder.AlterColumn<int>(
                name: "vehicle_type_id",
                table: "vehicles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes a 'one-to-many' relationship between the Vehicle and the VehicleType. Contains information about the type of the vehicle.");

            migrationBuilder.AlterColumn<string>(
                name: "model",
                table: "vehicles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Field that describes the model of the vehicle.");

            migrationBuilder.AlterColumn<short>(
                name: "max_seats",
                table: "vehicles",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComment: "Field that saves the max count of the vehicle seats.");

            migrationBuilder.AlterColumn<string>(
                name: "brand",
                table: "vehicles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Field that describes the brand of the vehicle.");

            migrationBuilder.AlterColumn<int>(
                name: "vehicle_id",
                table: "vehicles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Primary Key for the Vehicle Entity.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "label",
                table: "vehicle_type",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Label that contains the type.");

            migrationBuilder.AlterColumn<int>(
                name: "type_id",
                table: "vehicle_type",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Identfier of the vehicle type.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "people",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Foreign Key that is used to connect the Person Entity with the IdentityUser in the application.");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "people",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Field for the last name of the person.");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "people",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Field for the gender of the person.");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "people",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Field for the first name of the person.");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "people",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Field for the age of the person.");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "people",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Primary Key for the Person entity.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "vehicle_id",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Vehicle. Contains information about the vehicle with which the order will be run.");

            migrationBuilder.AlterColumn<int>(
                name: "driver_id",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes a 'one-to-many' relationship between the Order and Driver. Contains information about the driver that will run the order.");

            migrationBuilder.AlterColumn<int>(
                name: "destination_id",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the destination address of the order.");

            migrationBuilder.AlterColumn<int>(
                name: "current_address_id",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the current address of the order.");

            migrationBuilder.AlterColumn<short>(
                name: "count_of_passengers",
                table: "orders",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComment: "Field that saves the count of the passengers of the order.");

            migrationBuilder.AlterColumn<int>(
                name: "client_id",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the Client. Contains information about the client that made the order.");

            migrationBuilder.AlterColumn<int>(
                name: "odrer_id",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Primary Key of the Order Entity.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "person_id",
                table: "drivers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes the 'is a' relationship between the Driver and the Person.");

            migrationBuilder.AlterColumn<int>(
                name: "experience",
                table: "drivers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Filed for the years of experience of the driver.");

            migrationBuilder.AlterColumn<string>(
                name: "driving_licence",
                table: "drivers",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldComment: "Field that contains information about the driving licence of the driver.");

            migrationBuilder.AlterColumn<NpgsqlPoint>(
                name: "current_position",
                table: "drivers",
                type: "point",
                nullable: true,
                oldClrType: typeof(NpgsqlPoint),
                oldType: "point",
                oldNullable: true,
                oldComment: "Field that describes the current locaion of the driver by x and y coordinates.");

            migrationBuilder.AlterColumn<int>(
                name: "driver_id",
                table: "drivers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Primary Key for the Driver Entity.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "person_id",
                table: "clients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Foreign Key that describes the 'is a' relationship between the Client and the Person.");

            migrationBuilder.AlterColumn<bool>(
                name: "is_regular_customer",
                table: "clients",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Field that describes whether the client is regular.");

            migrationBuilder.AlterColumn<int>(
                name: "client_id",
                table: "clients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Primary Key for the Client Entity.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<NpgsqlPoint>(
                name: "location",
                table: "addresses",
                type: "point",
                nullable: true,
                oldClrType: typeof(NpgsqlPoint),
                oldType: "point",
                oldNullable: true,
                oldComment: "Field that describes the exact locaion of the address by x and y coordinates.");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "addresses",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Field that is used to make addtional description for the Address Entity which is optional.");

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "addresses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Primary Key of the Address Entity.")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
