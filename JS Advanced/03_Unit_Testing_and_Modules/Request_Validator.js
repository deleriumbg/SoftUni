function validate(request) {
    let invalidMethod = request.method !== 'GET' && request.method !== 'POST' && request.method !== 'DELETE' && request.method !== 'CONNECT';
    if (!request.hasOwnProperty('method')) {
        throw new Error('Invalid request header: Invalid Method');
    }
    if (invalidMethod) {
        throw new Error('Invalid request header: Invalid Method');
    }

    let validUriPattern = /^[A-Za-z0-9.*]+$/gm;
    if (!request.hasOwnProperty('uri') || !request.uri.match(validUriPattern)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    let invalidVersion = request.version !== 'HTTP/0.9' && request.version !== 'HTTP/1.0' && request.version !== 'HTTP/1.1' && request.version !== 'HTTP/2.0';
    if (!request.hasOwnProperty('version')) {
        throw new Error('Invalid request header: Invalid Version');
    }
    if (invalidVersion) {
        throw new Error('Invalid request header: Invalid Version');
    }

    let validMessagePattern = /^[^<>\\&'"]*$/gm;
    if (!request.hasOwnProperty('message')) {
        throw new Error('Invalid request header: Invalid Message');
    }
    if (!request.message.match(validMessagePattern)) {
        throw new Error('Invalid request header: Invalid Message');
    }
    return request;
}

console.log(validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));