import Joi from "joi";
export const logInSchema = Joi.object({
    email: Joi.string().email({ tlds: { allow: false } }).required().messages({
        'string.base': `invalid email`,
        'string.empty': `email cannot be empty`,
        'string.email': `enter a valid email`,
        'any.required': `email is required`
    }),
    password: Joi.string().min(4).required().messages({
        'string.base': `invalid password`,
        'string.empty': `password cannot be empty`,
        'any.required': `password is required`
    })
})