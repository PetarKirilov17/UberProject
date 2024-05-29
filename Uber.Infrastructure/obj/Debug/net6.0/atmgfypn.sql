START TRANSACTION;

ALTER TABLE "UberDb"."Vehicles" SET SCHEMA public;

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20230913124846_ChangingSchema', '6.0.20');

COMMIT;

