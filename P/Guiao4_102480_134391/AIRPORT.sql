CREATE TABLE AIRPORT (
    Airport_code VARCHAR(5) PRIMARY KEY,
    City VARCHAR(50),
    State VARCHAR(50),
    Name VARCHAR(100)
);

CREATE TABLE AIRPLANE_TYPE (
    Type_name VARCHAR(50) PRIMARY KEY,
    Max_seats INT,
    Company VARCHAR(50)
);

CREATE TABLE FLIGHT (
    Number INT PRIMARY KEY,
    Airline VARCHAR(50),
    Weekdays VARCHAR(50)
);
CREATE TABLE AIRPLANE (
    Airplane_id INT PRIMARY KEY,
    Total_no_of_seats INT,
    Type_name VARCHAR(50),
    CONSTRAINT FK_PLANE_TYPE FOREIGN KEY (Type_name) REFERENCES AIRPLANE_TYPE(Type_name)
);

-- Tabela de ligação N:M (Can_Land)
CREATE TABLE CAN_LAND (
    Airport_code VARCHAR(5),
    Type_name VARCHAR(50),
    PRIMARY KEY (Airport_code, Type_name),
    FOREIGN KEY (Airport_code) REFERENCES AIRPORT(Airport_code),
    FOREIGN KEY (Type_name) REFERENCES AIRPLANE_TYPE(Type_name)
);

CREATE TABLE FLIGHT_LEG (
    Flight_number INT,
    Leg_no INT,
    Sch_dep_time TIME,
    Sch_arr_time TIME,
    Dep_airport_code VARCHAR(5),
    Arr_airport_code VARCHAR(5),
    PRIMARY KEY (Flight_number, Leg_no),
    FOREIGN KEY (Flight_number) REFERENCES FLIGHT(Number),
    FOREIGN KEY (Dep_airport_code) REFERENCES AIRPORT(Airport_code),
    FOREIGN KEY (Arr_airport_code) REFERENCES AIRPORT(Airport_code)
);

CREATE TABLE LEG_INSTANCE (
    Flight_number INT,
    Leg_no INT,
    Dia DATE,
    No_of_avail_seats INT,
    Airplane_id INT,
    Dep_airport_code VARCHAR(5), -- Ligação "Departs"
    Dep_time TIME,
    Arr_airport_code VARCHAR(5), -- Ligação "Arrives"
    Arr_time TIME,
    PRIMARY KEY (Flight_number, Leg_no, Dia),
    FOREIGN KEY (Flight_number, Leg_no) REFERENCES FLIGHT_LEG(Flight_number, Leg_no),
    FOREIGN KEY (Airplane_id) REFERENCES AIRPLANE(Airplane_id),
    FOREIGN KEY (Dep_airport_code) REFERENCES AIRPORT(Airport_code),
    FOREIGN KEY (Arr_airport_code) REFERENCES AIRPORT(Airport_code)
);

CREATE TABLE SEAT (
    Flight_number INT,
    Leg_no INT,
    Dia DATE,
    Seat_no VARCHAR(10),
    Customer_name VARCHAR(100),
    Cphone VARCHAR(20),
    PRIMARY KEY (Flight_number, Leg_no, Dia, Seat_no),
    FOREIGN KEY (Flight_number, Leg_no, Dia) REFERENCES LEG_INSTANCE(Flight_number, Leg_no, Dia)
);

CREATE TABLE FARE (
    Flight_Number INT NOT NULL,
    Code VARCHAR(10) NOT NULL, 
    Amount DECIMAL(10, 2) NOT NULL, 
    Restrictions VARCHAR(255), 
    CONSTRAINT PK_FARE PRIMARY KEY (Flight_Number, Code),
    CONSTRAINT FK_FARE_FLIGHT FOREIGN KEY (Flight_Number) REFERENCES FLIGHT(Number),
);