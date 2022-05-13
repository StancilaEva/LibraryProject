import { Alert } from "@mui/material";
import { IconButton } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import { Collapse } from "@mui/material";
function UnsuccessfulMessage(props) {
    const { setShowMessage, message } = props
    return (
        <Alert
            severity="error"
            action={
                <IconButton
                    aria-label="close"
                    color="inherit"
                    size="small"
                    onClick={() => {
                        setShowMessage(false);
                    }}
                >
                    <CloseIcon fontSize="inherit" />
                </IconButton>
            }
            sx={{ mb: 2 }}
        >
            {message}
        </Alert>
    )
}
export default UnsuccessfulMessage;