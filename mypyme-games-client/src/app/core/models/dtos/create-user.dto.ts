import { UserRole } from "../types/user-role.type";

export interface CreateUserDto {
    username: string;
    email?: string;
    password?: string;
    firstName?: string;
    lastName?: string;
    role: UserRole;
}
