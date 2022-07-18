import { Routes,Route,Router } from "react-router-dom"
import ClientAddress from "./Components/Screens/ClientAddressPage";
import ClientLends from "./Components/Screens/ClientsLendPage";
import LendPage from "./Components/Screens/LendPage";
import ComicBookPage from "./Components/Screens/ComicBookPage";
import AltHomePage from "./Components/Screens/AlternativeHomePage"
import SignUpStepper from "./Components/Screens/SignUpStepper";
import './index.css';
import LogIn from "./Components/Screens/LogIn";
import LendDatePicker from "./Components/Cards/LendDatePicker";
import { ThemeProvider } from "@mui/material/styles";
import { greenTheme } from "./Themes/greenTheme";
import { CssBaseline } from "@mui/material";
import { UserContext } from "./Context/userContext";
import { useState } from "react";
import { useMemo } from "react";
import PrivateRoute from "./PrivateRouter/PrivateRouter";
import StatsPage from "./Components/Screens/StatsPage";
import LendTimesDialog from "./Components/Cards/Dialog/LendTimesDialog";
import FavoritesPage from "./Components/Screens/FavoritesPage";
import AdminPage from "./Components/Screens/AdminPage";
import PrivateAdminRoute from "./PrivateRouter/PrivateAdminRouter";
import AddComicBookPage from "./Components/Screens/AddComicBookPage";


function App() {
  const [user,setUser] = useState(null)
  return (
    <ThemeProvider theme={greenTheme}>
    <CssBaseline/>
    <UserContext.Provider value={{user,setUser}}>
    <Routes>
            <Route path="/" exact element={
            <PrivateRoute>
            <AltHomePage/>
            </PrivateRoute>
            }/>
            <Route path="/Client/Address" exact element={
            <PrivateRoute>
              <ClientAddress/>
              </PrivateRoute>}/>
            <Route path="/Client/Lends" exact  element={
            <PrivateRoute>
              <ClientLends/>
              </PrivateRoute>}/>
            <Route path="Lends/:id" exact element={
            <PrivateRoute>
            <LendPage/>
            </PrivateRoute>}></Route>
            <Route path="/ComicBook/:id" exact element={
            <PrivateRoute>
            <ComicBookPage/>
            </PrivateRoute>
             }></Route>
             <Route path="/Stats" exact element={
            <PrivateRoute>
            <StatsPage/>
            </PrivateRoute>
             }></Route>
             <Route path="/Favorites" exact element={
            <PrivateRoute>
            <FavoritesPage/>
            </PrivateRoute>
             }></Route>
             <Route path="/Admin" exact element={
              <PrivateAdminRoute>
                <AdminPage/>
              </PrivateAdminRoute>
             }>
             </Route>
             <Route path="/ComicBook" exact element={
              <PrivateAdminRoute>
                <AddComicBookPage/>
              </PrivateAdminRoute>
             }>
             </Route>
            <Route path="/Signup" exact element={<SignUpStepper/>}></Route>
            <Route path="/LogIn" exact element={<LogIn/>}></Route>
            <Route path="/DatePicker" exact element={<LendTimesDialog/>}></Route>
            
    </Routes>
    </UserContext.Provider>
    </ThemeProvider>
  );
}

export default App;