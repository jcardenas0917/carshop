export interface IUser {
  id: string;
  email: string;
  fullName: string;
  address: string;
  city: string;
  state: string;
}

export enum UserProperties {
  ID = 'id',
  EMAIL = 'email',
  FULLNAME = 'fullName',
  ADDRESS = 'address',
  CITY = 'city',
  STATE = 'state'
}
