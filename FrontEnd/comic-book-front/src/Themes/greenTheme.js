import { createTheme } from "@mui/material/styles";
export const greenTheme = createTheme({
  palette: {
    type: 'light',
    primary: {
      main: '#ADC2A9',
    },
    secondary: {
      main: '#E9B2BC',
      light: '#E9B2BC',
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