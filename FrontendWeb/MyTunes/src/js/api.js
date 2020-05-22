// window.API = async (requete, callback = ((a) => {return a})) => {
//     const response = await fetch(`https://mytunes20200429155409.azurewebsites.net/api/${requete}`);
//     const json = await response.json();
//     return callback(json);
// }
// window.API = (requete, succes, error = ((a) => {return a})) => {
//     this.$http.get(`https://mytunes20200429155409.azurewebsites.net/api/${requete}`).then((res) => {
//         success(res)
//     }, (res) => {
//         error(res)
//         console.log('error', res)
//     })
// }
window.API = `https://mytunes20200429155409.azurewebsites.net/api/`
