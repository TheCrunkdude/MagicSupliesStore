
export interface rolePermissionsTable{
    id: number,
    permission: number,
    role: number,
    active: boolean
  }

export interface rolePermissionsTableFilter{
  permissions: string,
  role: string,
}
