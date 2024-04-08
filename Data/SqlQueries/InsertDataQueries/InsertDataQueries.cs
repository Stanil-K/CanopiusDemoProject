namespace Data.SqlQueries.InsertDataQueries
{
    internal class InsertDataQueries
    {
        //  Insert data into Customers query

        //     INSERT INTO CanopiusDemoApp.dbo.Customers(Name, Address, Phone, Email, DateofBirth)
        //      ID     VALUES
        //      1 ('John Doe', '123 Main St, New York, USA', '555-1345', 'johndoe@email.com', '1980-01-01'),
        //      2 ('Alice Smith', '456 Elm St, Los Angeles, USA', '555-9876', 'alicesmith@email.com', '1990-05-15'),
        //      3 ('Bob Johnson', '789 Oak St, Chicago, USA', '555-5432', 'bjohnson@email.com', '1975-09-30'),
        //      4 ('Emily Brown', '101 Pine St, San Francisco, USA', '555-7890', 'emilybrown@email.com', '1988-03-20'),
        //      5 ('Michael Lee', '202 Maple St, Boston, USA', '555-3210', 'michaellee@email.com', '1995-07-10'),
        //      6 ('Emma Davis', '303 Cedar St, Seattle, USA', '555-4567', 'emmadavis@email.com', '1983-11-25'),
        //      7 ('David Wilson', '404 Walnut St, Miami, USA', '555-2345', 'davidwilson@email.com', '1970-04-05'),
        //      8 ('Olivia Taylor', '505 Birch St, Dallas, USA', '555-6789', 'oliviataylor@email.com', '1992-08-12'),
        //      9 ('James Martinez', '606 Pineapple St, Houston, USA', '555-8901', 'jamesmartinez@email.com', '1978-12-15'),
        //      10 ('Sophia Rodriguez', '707 Orange St, Atlanta, USA', '555-5678', 'sophiarodriguez@email.com', '1986-06-28'),
        //      11 ('John Smith', '123 Main St, New York, USA', '555-1234', 'john@example.com', '1985-03-12'),
        //      12 ('Emily Johnson', '456 Elm St, Los Angeles, USA', '555-5678', 'emily@example.com', '1990-07-25'),
        //      13 ('Michael Brown', '789 Oak St, Chicago, USA', '555-9012', 'michael@example.com', '1982-10-18'),
        //      14 ('Sarah Davis', '101 Maple St, Houston, USA', '555-3456', 'sarah@example.com', '1978-05-05'),
        //      15 ('Olivia Wilson', '202 Pine St, Miami, USA', '555-7890', 'olivia@example.com', '1993-09-28'),
        //      16 ('Daniel Martinez', '303 Cedar St, Boston, USA', '555-2345', 'daniel@example.com', '1987-12-15'),
        //      17 ('Sophia Taylor', '404 Birch St, Seattle, USA', '555-6789', 'sophia@example.com', '1995-02-08'),
        //      18 ('William Lee', '505 Walnut St, San Francisco, USA', '555-0123', 'william@example.com', '1980-08-20'),
        //      19 ('Ella Rodriguez', '606 Ash St, Denver, USA', '555-4567', 'ella@example.com', '1989-11-03'),
        //      20 ('James Moore', '707 Cherry St, Philadelphia, USA', '555-8901', 'james@example.com', '1984-06-16');


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //  Insert data into Policies query

        //    INSERT INTO CanopiusDemoApp.dbo.Policies(CustomerId, PolicyType, StartDate, EndDate, PremiumAmount)
        //    VALUES
        //        (1, 'Life Insurance', '2023-01-01', '2028-01-01', 100.50),
        //        (2, 'Health Insurance', '2022-05-01', '2023-05-01', 200.75),
        //        (3, 'Car Insurance', '2021-09-01', '2022-09-01', 300.25),
        //        (4, 'Home Insurance', '2023-03-01', '2024-03-01', 400.00),
        //        (5, 'Travel Insurance', '2024-07-01', '2025-07-01', 150.00),
        //        (6, 'Pet Insurance', '2020-11-01', '2021-11-01', 75.50),
        //        (7, 'Renters Insurance', '2022-04-01', '2023-04-01', 120.75),
        //        (8, 'Business Insurance', '2023-08-01', '2024-08-01', 250.00),
        //        (9, 'Flood Insurance', '2022-12-01', '2023-12-01', 180.25),
        //        (10, 'Earthquake Insurance', '2021-06-01', '2022-06-01', 220.50),
        //        (11, 'Life Insurance', '2023-01-01', '2028-01-01', 100.50),
        //        (12, 'Health Insurance', '2022-05-01', '2023-05-01', 200.75),
        //        (13, 'Car Insurance', '2021-09-01', '2022-09-01', 300.25),
        //        (14, 'Home Insurance', '2023-03-01', '2024-03-01', 400.00),
        //        (15, 'Travel Insurance', '2024-07-01', '2025-07-01', 150.00),
        //        (16, 'Pet Insurance', '2020-11-01', '2021-11-01', 75.50);



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //  Insert data into Claims query

        //    INSERT INTO CanopiusDemoApp.dbo.Claims(PolicyId, DateOfClaim, ClaimAmount, ClaimDescription, ClaimStatus)
        //    VALUES
        //        (1, '2023-02-15', 50000.00, 'Life insurance claim for John Doe', 'Pending'),
        //        (2, '2022-06-20', 2000.00, 'Health insurance claim for Alice Smith', 'Approved'),
        //        (3, '2021-11-10', 1000.00, 'Car insurance claim for Bob Johnson', 'Rejected'),
        //        (4, '2023-04-25', 30000.00, 'Home insurance claim for Emily Brown', 'Pending'),
        //        (5, '2024-08-05', 1500.00, 'Travel insurance claim for Michael Lee', 'Pending'),
        //        (6, '2021-12-30', 200.00, 'Pet insurance claim for Emma Davis', 'Approved'),
        //        (7, '2023-05-15', 500.00, 'Renters insurance claim for David Wilson', 'Rejected'),
        //        (8, '2024-09-01', 10000.00, 'Business insurance claim for Olivia Taylor', 'Pending'),
        //        (9, '2023-01-20', 8000.00, 'Flood insurance claim for James Martinez', 'Approved'),
        //        (10, '2022-07-10', 5000.00, 'Earthquake insurance claim for Sophia Rodriguez', 'Rejected'),
        //        (11, '2023-02-15', 50.00, 'Life insurance claim for John Smith', 'Pending'),
        //        (12, '2022-06-20', 20.00, 'Health insurance claim for Emily Johnson', 'Pending');


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //  Insert data into Payments query

    //    INSERT INTO CanopiusDemoApp.dbo.Payments(ClaimId, PaymentDate, PaymentAmount, PaymentType)
    //    VALUES
    //        (1, '2023-03-01', 1000.00, 'Premium Payment'),
    //        (2, '2022-07-01', 200.00, 'Claim Payment'),
    //        (3, '2021-12-01', 300.00, 'Premium Payment'),
    //        (4, '2023-05-01', 4000.00, 'Claim Payment'),
    //        (5, '2024-09-01', 150.00, 'Premium Payment'),
    //        (6, '2022-01-01', 50.00, 'Premium Payment'),
    //        (7, '2023-07-01', 200.00, 'Claim Payment'),
    //        (8, '2024-01-01', 500.00, 'Premium Payment'),
    //        (9, '2023-05-01', 4000.00, 'Premium Payment'),
    //        (10, '2022-10-01', 3000.00, 'Claim Payment');

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
