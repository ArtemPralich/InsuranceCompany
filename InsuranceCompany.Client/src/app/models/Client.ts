export class Client {
    Id : string;
    Name : string;
    Surname : string;
    Gender : boolean;
    DateOfBirth : Date;
    // ClientaChildren { get; } = new List<ClientaChild>();
    // PositionClients { get; } = new List<PositionClient>();
  
    constructor(id: string, name: string, surname: string, gender: boolean, dateOfBirth: Date) {
        this.Id = id;
        this.Name = name;
        this.Surname = surname;
        this.Gender = gender;
        this.DateOfBirth = dateOfBirth;
    }
  }
  