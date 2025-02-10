export interface userRolesTable{
    id: number,
    user: number,
    role: number,
    active: boolean
  }

export interface userRolesTableFilter{
  user: string,
  roles: string,
}
