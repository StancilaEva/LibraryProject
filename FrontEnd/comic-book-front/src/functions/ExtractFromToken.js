export const getRole = (token) =>{
    let jwtData = token.split('.')[1]
    let decodedJwtJsonData = window.atob(jwtData)
    let decodedJwtData = JSON.parse(decodedJwtJsonData)
    const role = decodedJwtData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    return role
}