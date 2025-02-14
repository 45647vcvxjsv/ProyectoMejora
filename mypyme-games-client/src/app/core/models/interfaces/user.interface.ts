import { UserRole } from "../types/user-role.type";

export interface User {
    id: number;
    username: string;
    email?: string;
    firstName?: string;
    lastName?: string;
    role: UserRole;
    createdAt: Date;
    updatedAt: Date;
}