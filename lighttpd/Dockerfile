FROM alpine:3.12

LABEL maintainer="Sebastian Teumert <sebastian.teumert@gmx.de>"

# Install packages
RUN apk update && \
    apk add --no-cache \
    lighttpd \
    bash \
    curl && \
    rm -rf /var/cache/apk/*

# copy config
COPY conf/* /etc/lighttpd/

# copy entry point script
COPY lighttpd-docker /usr/local/bin/

# copy document root
COPY htdocs/* /var/www/localhost/htdocs/

# create cache/compress dir
RUN mkdir -p /var/lib/lighttpd/cache/compress && chown lighttpd:lighttpd /var/lib/lighttpd/cache/compress

HEALTHCHECK --interval=15s --timeout=1s \
  CMD curl -f https://localhost/ || exit 1

# Expose http port
EXPOSE 8080

ENTRYPOINT ["lighttpd-docker"]
