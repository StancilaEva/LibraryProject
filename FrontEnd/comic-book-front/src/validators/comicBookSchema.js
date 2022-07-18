import Joi from "joi";
export const comicBookSchema = Joi.object({
    title: Joi.string().required().invalid("Empty", "").messages({
        'string.base': `invalid title`,
        'string.empty': `title cannot be empty`,
        'any.required': `title is required`,
        'any.invalid': 'title cannot be empty'
    }),
    issueNumber: Joi.number().required().greater(0).messages({
        'number.base': 'issue must be a number',
        'any.required': `issue number is required`,
        'number.greater': `issue number must be greater than 0`
    }),
    publisher: Joi.string().required().invalid("Empty", "").messages({
        'string.base': `invalid publisher`,
        'string.empty': `publisher cannot be empty`,
        'any.required': `publisher is required`,
        'any.invalid': 'publisher cannot be empty'
    }),
    genre: Joi.string().required().invalid("Empty", "").messages({
        'string.base': `invalid genre`,
        'string.empty': `genre cannot be empty`,
        'any.required': `genre is required`,
        'any.invalid': 'genre cannot be empty'
    }),
    cover: Joi.string().required().invalid("Empty", "").messages({
        'string.base': `invalid cover`,
        'string.empty': `cover cannot be empty`,
        'any.required': `cover is required`,
        'any.invalid': 'cover cannot be empty'
    })
})