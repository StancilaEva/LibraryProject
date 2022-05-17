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
function App() {
  return (
    <ThemeProvider theme={greenTheme}>
      <CssBaseline/>
    <Routes>
            <Route path="/" exact element={<AltHomePage/>}></Route>
            <Route path="/Client/:id/Address" exact element={<ClientAddress/>}/>
            <Route path="/Client/:id/Lends" exact  element={<ClientLends/>}/>
            <Route path="Lends/:id" exact element={<LendPage/>}></Route>
            <Route path="/ComicBook/:id" exact element={<ComicBookPage/>}></Route>
            <Route path="/Signup" exact element={<SignUpStepper/>}></Route>
            <Route path="/LogIn" exact element={<LogIn/>}></Route>
            <Route path="/DatePicker" exact element={<LendDatePicker/>}></Route>
    </Routes>
    </ThemeProvider>
  );
}

export default App;