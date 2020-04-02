export interface IUser {
  email: string;
  fullname: string;
  address: string;
  city: string;
  state: string;
}

export enum UserProperties {
  EMAIL = 'email',
  FULLNAME = 'fullName',
  ADDRESS = 'address',
  CITY = 'city',
  STATE = 'state'
}
