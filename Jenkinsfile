podTemplate(
    name: 'test-pod',
    label: 'test-pod',
    containers: [
        containerTemplate(name: 'jnlp', image:'registry.check.com/netcore/jnlp-slave:3.40'),
    ],
    volumes: [
        hostPathVolume(mountPath: '/var/run/docker.sock',hostPath: '/var/run/docker.sock')
    ],
    {
        //node = the pod label
        node('test-pod'){
            //container = the container label
            stage('Build'){
                container('jnlp'){
                    echo "build test"
                    // This is where we build our code.
                }
            }
        }
    })