import { Photo } from './photo';

export interface User {
    userDetailId: number;
    firstName: string;
    middleName: string;
    lastName: string;
    photos: Photo[];
    departmentId: number;
    department: string;
    employmentTypeId: number;
    employmentType: string;
    userAccountId: number;
    userRole: string;
    photoUrl: string;
}
