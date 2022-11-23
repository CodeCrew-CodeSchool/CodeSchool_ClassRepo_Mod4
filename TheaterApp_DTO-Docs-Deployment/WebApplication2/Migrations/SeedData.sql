Begin Transaction

Insert into People ([Name])
VALUES ('Tyler Perry')

Insert into Venues ([Name])
VALUES ('Memphis Orpheum')

Insert into Shows ([Title], [VenueId])
VALUES ('Madea Learns to Code', 1)

Insert into Casts ([ShowId], [ShowName], [JobTitle], [PersonId], [PersonName])
VALUES (1, 'Madea Learns to Code', 'Lead Actor', 1, 'Tyler Perry')



END

--Commit
--Rollback