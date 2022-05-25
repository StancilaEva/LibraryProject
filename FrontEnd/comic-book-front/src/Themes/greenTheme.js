import { createTheme } from "@mui/material/styles";
export const greenTheme = createTheme({
  palette: {
    type: 'light',
    primary: {
      main: '#ADC2A9',
    },
    secondary: {
      main: '#FFE5B4',
      light: '#FFE5B4',
    },
    background: {
      default: '#FEF5ED',
      paper: '#D3E4CD',
    },
    text: {
      primary: '#435560',
    },
  },
});